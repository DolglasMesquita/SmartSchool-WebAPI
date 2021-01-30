﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Data;
using SmartSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repository;

        public ProfessorController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repository.GetAllProfessores(true);
            return Ok(professores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repository.GetProfessorById(id, true);
            if (professor == null) return  BadRequest("Professor não encontrado");

            return Ok(professor);
        }

        [HttpGet("disciplina/{disciplinaId}")]
        public IActionResult GetByDisciplina(int disciplinaId)
        {
            var professores = _repository.GetAllProfessoresByDisciplinaId(disciplinaId, true);
            if (professores == null) return BadRequest("Professor não encontrado");

            return Ok(professores);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repository.Add(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Erro ao adicionar professor");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repository.GetProfessorById(id, true);
            if (prof == null) return BadRequest("Professor não encontrado");

            _repository.Update(professor);
            if (_repository.SaveChanges()) return Ok(professor); 
            return BadRequest("Professor não atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repository.GetProfessorById(id, true);
            if (prof == null) return BadRequest("Professor não encontrado");

            _repository.Update(professor);
            if (_repository.SaveChanges()) return Ok(professor);
            return BadRequest("Professor não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repository.GetProfessorById(id, true);
            if (professor == null) return BadRequest("Professor não encontrado");

            _repository.Delete(professor);
            if (_repository.SaveChanges()) return Ok("Professor removido");
            return BadRequest("Professor não removido");
        }
    }
}
