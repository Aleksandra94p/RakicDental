using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RakicDental.Interfaces;
using RakicDental.Models.DTO;
using RakicDental.Models;
using RakicDental.Repository;
using System.Collections.Generic;

namespace RakicDental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientsController(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var result = _patientRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<PatientDTO>>(result));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetOne(int id)
        {
            if (id < 0)
            {
                return BadRequest("Invalid Id!");
            }

            var result = _patientRepository.GetOne(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PatientDTO>(result));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _patientRepository.Create(patient);

            return CreatedAtAction("GetOne", new { id = patient.Id }, _mapper.Map<PatientDTO>(patient));

        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Update(int id, Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != patient.Id)
            {
                return BadRequest("Invalid Id!");
            }

            try
            {
                _patientRepository.Update(patient);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<PatientDTO>(patient));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            var result = _patientRepository.GetOne(id);
            if (result == null)
            {
                return BadRequest();
            }
            _patientRepository.Delete(result);
            return NoContent();
        }

        [HttpGet]
        [Route("pronadji")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }
            var result = _patientRepository.GetByName(name);
            return Ok(_mapper.Map<IEnumerable<PatientDTO>>(result));

        }


    }
}
