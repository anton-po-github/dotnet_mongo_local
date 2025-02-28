﻿﻿
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

[Produces("application/json")]
[Consumes("application/json", "multipart/form-data")]
[Route("api/[controller]")]
public class NotesController : Controller
{
    private readonly NoteService _noteRepository;

    public NotesController(NoteService noteRepository)
    {
        _noteRepository = noteRepository;
    }

    //  [NoCache]
    [HttpGet]
    public Task<IEnumerable<Note>> Get()
    {
        return GetNoteInternal();
    }

    private async Task<IEnumerable<Note>> GetNoteInternal()
    {
        return await _noteRepository.GetAllNotes();
    }

    // GET api/notes/5
    [HttpGet("{id}")]
    public Task<Note> Get(string id)
    {
        return GetNoteByIdInternal(id);
    }

    private async Task<Note> GetNoteByIdInternal(string id)
    {
        return await _noteRepository.GetNote(id) ?? new Note();
    }

    // POST api/notes
    [HttpPost]
    public void Post([FromBody] string value)
    {
        _noteRepository.AddNote(new Note() { Body = value, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
    }

    // PUT api/notes/5
    /*   [HttpPut ("{id}")]
      public void Put (string id, [FromBody] string value) {
          _noteRepository.UpdateNoteDocument (id, value);
      } */

    // DELETE api/notes/23243423
    [HttpDelete("{id}")]
    public void Delete(string id)
    {
        _noteRepository.RemoveNote(id);
    }

    // POST api/notes/uploadFile
    [HttpPost("uploadFile")]
    public async Task<ObjectId> UploadFile(IFormFile file)
    {
        return await _noteRepository.UploadFile(file);
    }
    // GET api/notes/getFileInfo/d1we24ras41wr
    [HttpGet("getFileInfo/{id}")]
    public Task<String> GetFileInfo(string id)
    {
        return _noteRepository.GetFileInfo(id);
    }
}