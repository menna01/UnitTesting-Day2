using CarAPI.Entities;
using CarFactoryAPI.Entities;
using CarFactoryAPI.Repositories_DAL;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryAPI_Tests
{
    public class OwnerRepositoryTests
    {
        // Create Mock of Dependencies
        Mock<FactoryContext> contextMock;

        // use fake object as dependency
        OwnerRepository ownerRepository;

        public OwnerRepositoryTests()
        {
            // Create Mock of Dependencies
            contextMock = new();

            // use fake object as dependency
            ownerRepository = new(contextMock.Object);
        }
        //[Fact(Skip = "iam still work on")]
        [Fact()]
        [Trait("Author", "Menna")]
        [Trait("Priorty", "50")]
        public void GetOwnerById_AskForOwnerId2_OwnerObject()
        {
            // Arrange
            // Build the mock data
            List<Owner> owners = new List<Owner>() {
                new Owner() { Id = 1 },
                new Owner() { Id = 2 },
                new Owner() { Id = 3 }
            };

            // setup called Dbsets
            contextMock.Setup(o => o.Owners).ReturnsDbSet(owners);

            // Act
            Owner result = ownerRepository.GetOwnerById(2);

            // Assert
            Assert.NotNull(result);
        }

        [Fact()]
        [Trait("Author", "Menna")]
        [Trait("Priorty", "60")]
        public void GetAllOwners_AskForAllOwners_OwnerObject()
        {
            // Arrange
            // Build the mock data
            List<Owner> owners = new List<Owner>() {
                new Owner() { Id = 1, Name="Menna" },
                new Owner() { Id = 2, Name="Ahmed"},
                new Owner() { Id = 3 , Name="Ibrahim"}
            };

            // setup called Dbsets
            contextMock.Setup(o => o.Owners).ReturnsDbSet(owners);

            // Act
            List<Owner> result = ownerRepository.GetAllOwners();

            // Assert
            Assert.NotEmpty(result);
        }
    }
}
