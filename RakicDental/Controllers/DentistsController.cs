using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RakicDental.Interfaces;
using RakicDental.Models;
using RakicDental.Models.DTO;
using System.Collections;
using System.Collections.Generic;

namespace RakicDental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistsController : ControllerBase
    {
        private readonly IDentistRepository _dentistRepository;
        private readonly IMapper _mapper;

        public DentistsController(IDentistRepository dentistRepository, IMapper mapper)
        {
            _dentistRepository = dentistRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var result = _dentistRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<DentistDTO>>(result));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetOne(int id)
        {
            if(id < 0) 
                {
                return BadRequest("Invalid Id!");
                }

            var result = _dentistRepository.GetOne(id);
            if(result == null) 
                {
                return NotFound();
                }
            return Ok(_mapper.Map<DentistDTO>(result));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Create(Dentist dentist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _dentistRepository.Create(dentist);
            
            return CreatedAtAction("GetOne", new { id = dentist.Id }, _mapper.Map<DentistDTO>(dentist));

        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Update(int id, Dentist dentist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != dentist.Id)
            {
                return BadRequest("Invalid Id!");
            }

            try
            {
                _dentistRepository.Update(dentist);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<DentistDTO>(dentist));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            var result = _dentistRepository.GetOne(id);
            if (result == null)
            {
                return BadRequest();
            }
            _dentistRepository.Delete(result);
            return NoContent();
        }
    }
}
