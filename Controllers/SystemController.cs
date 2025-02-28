﻿﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860


[Route("api/[controller]")]
public class SystemController : Controller
{
    private readonly NoteService _noteRepository;

    public SystemController(NoteService noteRepository)
    {
        _noteRepository = noteRepository;
    }

    // Call an initialization - api/system/init
    [HttpGet("{setting}")]
    public string Get(string setting)
    {
        if (setting == "init")
        {
            _noteRepository.RemoveAllNotes();
            _noteRepository.AddNote(new Note() { Id = "1", Body = "Test note 1", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UserId = 1 });
            _noteRepository.AddNote(new Note() { Id = "2", Body = "Test note 2", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UserId = 1 });
            _noteRepository.AddNote(new Note() { Id = "3", Body = "Test note 3", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UserId = 2 });
            _noteRepository.AddNote(new Note() { Id = "4", Body = "Test note 4", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now, UserId = 2 });

            return "Done";
        }

        return "Unknown";
    }
}