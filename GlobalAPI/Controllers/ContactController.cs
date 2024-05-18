using Business;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GlobalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactService _contactService;

        public ContactController(ContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetAllContacts()
        {
            return _contactService.GetAllContacts();
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            _contactService.AddContact(contact);
            return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            _contactService.UpdateContact(contact);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            _contactService.DeleteContact(id);

            return NoContent();
        }
    }
}
