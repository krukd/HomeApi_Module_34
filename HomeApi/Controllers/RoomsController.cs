﻿using System.Threading.Tasks;
using AutoMapper;
using HomeApi.Contracts.Models.Rooms;
using HomeApi.Data.Models;
using HomeApi.Data.Repos;
using Microsoft.AspNetCore.Mvc;
using HomeApi.Data.Queries;

namespace HomeApi.Controllers
{
    /// <summary>
    /// Контроллер комнат
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        private IRoomRepository _repository;
        private IMapper _mapper;
        
        public RoomsController(IRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        //TODO: Задание - добавить метод на получение всех существующих комнат
        
        /// <summary>
        /// Добавление комнаты
        /// </summary>
        [HttpPost] 
        [Route("")] 
        public async Task<IActionResult> Add([FromBody] AddRoomRequest request)
        {
            var existingRoom = await _repository.GetRoomByName(request.Name);
            if (existingRoom == null)
            {
                var newRoom = _mapper.Map<AddRoomRequest, Room>(request);
                await _repository.AddRoom(newRoom);
                return StatusCode(201, $"Комната {request.Name} добавлена!");
            }
            
            return StatusCode(409, $"Ошибка: Комната {request.Name} уже существует.");
        }


        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateRoom([FromBody] AddRoomRequest request)
        {
            var updateRoom = await _repository.GetRoomByName(request.Name);
            if (updateRoom == null)
                return StatusCode(400, $"Комната не найдена");

            await _repository.UpdateRoom(updateRoom, new UpdateRoomQuery(request.Name, request.Area, request.GasConnected, request.Voltage));

            return StatusCode(200, $"Комната {request.Name} была обновлена");
        }

    }
}