using Business;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyProject.Tests
{
    public class ContactServiceTests
    {
        [Fact]
        public void GetAllContacts_ReturnsAllContacts()
        {
            // Arrange
            var contacts = new List<Contact>
            {
                new Contact { Id = 1, Name = "John", Email = "john@example.com", Subject = "Test Subject 1", Message = "Test Message 1" },
                new Contact { Id = 2, Name = "Jane", Email = "jane@example.com", Subject = "Test Subject 2", Message = "Test Message 2" }
            }.AsQueryable();

            // Setup mock DbSet
            var mockDbSet = new Mock<DbSet<Contact>>();
            mockDbSet.SetupAllProperties();
            mockDbSet.As<IQueryable<Contact>>().Setup(m => m.Provider).Returns(contacts.Provider);
            mockDbSet.As<IQueryable<Contact>>().Setup(m => m.Expression).Returns(contacts.Expression);
            mockDbSet.As<IQueryable<Contact>>().Setup(m => m.ElementType).Returns(contacts.ElementType);
            mockDbSet.As<IQueryable<Contact>>().Setup(m => m.GetEnumerator()).Returns(contacts.GetEnumerator());

            // Setup mock DbContext
            var mockDbContext = new Mock<GlobalDbContext>();
            mockDbContext.Setup(x => x.Contacts).Returns(mockDbSet.Object);

            var contactService = new ContactService(mockDbContext.Object);

            // Act
            var result = contactService.GetAllContacts();

            // Assert
            Assert.Equal(contacts.Count(), result.Count);

            // Additional assertions
            foreach (var expectedContact in contacts)
            {
                var actualContact = result.FirstOrDefault(c => c.Id == expectedContact.Id);
                Assert.NotNull(actualContact);
                Assert.Equal(expectedContact.Name, actualContact.Name);
                Assert.Equal(expectedContact.Email, actualContact.Email);
                Assert.Equal(expectedContact.Subject, actualContact.Subject);
                Assert.Equal(expectedContact.Message, actualContact.Message);
            }
        }

        // Diğer testler buraya eklenebilir

        // Clean up resources if needed
        public void Dispose()
        {
            // Dispose any disposable resources
        }
    }
}
