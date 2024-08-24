using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RakicDental.Interfaces;
using RakicDental.Models;
using RakicDental.Models.DTO;
using RakicDental.Repository;
using System.Collections;
using System.Collections.Generic;

namespace RakicDental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentsController : ControllerBase
    {
        private readonly ITreatmentsRepository _treatmentsRepository;
        private readonly IMapper _mapper;

        public TreatmentsController(ITreatmentsRepository treatmentsRepository, IMapper mapper)
        {
            _treatmentsRepository = treatmentsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
            {
            var result  = _treatmentsRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<TreatmentDTO>>(result));
            }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetOne(int id) 
            {
            if(id < 0) 
                {
                return BadRequest();
                }
            var result = _treatmentsRepository.GetOne(id);
             if(result == null) 
                {
                return NotFound();
                }
            return Ok(_mapper.Map<TreatmentDTO>(result));
            }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Create(Treatment treatment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _treatmentsRepository.Create(treatment);
            
            return CreatedAtAction("GetOne", new { id = treatment.Id }, _mapper.Map<TreatmentDTO>(treatment));

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Update(int id, Treatment treatment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != treatment.Id)
            {
                return BadRequest("Invalid Id!");
            }

            try
            {
                _treatmentsRepository.Update(treatment);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<Treatment>(treatment));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            var result = _treatmentsRepository.GetOne(id);
            if (result == null)
            {
                return BadRequest();
            }
            _treatmentsRepository.Delete(result);
            return NoContent();
        }


    }
}
