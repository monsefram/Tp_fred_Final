using Moq;
using System.Collections.Generic;
using Tp_Final_Fred.Data.Repositories.Interfaces;
using Tp_Final_Fred.Models;
using Tp_Final_Fred.ViewModels;
using Xunit;

namespace Tp_Final_Fred.Tests.ViewModels
{
    public class MainViewModelTests
    {
        // =========================
        // Variables d’instances (Mocks)
        // =========================
        private readonly Mock<IRegionRepository> _regionRepoMock
            = new Mock<IRegionRepository>();

        // =========================
        // Constructeur des tests
        // =========================
        public MainViewModelTests()
        {
            // Aucun comportement global requis ici
            // (contrairement à IDialogueService dans l'exemple du cours)
        }

        // =========================
        // Test du constructeur
        // =========================
        [Fact]
        public void Constructeur_ShouldLoadRegionsFromRepository()
        {
            // Préparation
            _regionRepoMock
                .Setup(r => r.GetAll())
                .Returns(ListeRegionsAttendues());

            // Exécution
            MainViewModel vm =
                new MainViewModel(_regionRepoMock.Object);

            // Validation
            Assert.Equal(2, vm.Regions.Count);
            Assert.Equal("Montreal", vm.Regions[0].Name);
            Assert.Equal("Quebec", vm.Regions[1].Name);
        }

        // =========================
        // Test de AddRegion
        // =========================
        [Fact]
        public async Task AddRegion_ShouldAddRegion()
        {
            // Arrange
            _regionRepoMock.Setup(r => r.GetAll())
                .Returns(new List<Region>
                {
            new Region
            {
                Name = "Shawinigan",
                Latitude = 46.5698,
                Longitude = -72.7381
            }
                });

            _regionRepoMock
                .Setup(r => r.AddAsync(It.IsAny<Region>()))
                .ReturnsAsync((Region r) => r);

            var vm = new MainViewModel(_regionRepoMock.Object);

            vm.RegionName = "TestRegion";
            vm.Latitude = 1;
            vm.Longitude = 2;

            // Act
            await vm.AddRegion();

            // Assert
            Assert.Equal(2, vm.Regions.Count);
            Assert.Contains(vm.Regions, r => r.Name == "TestRegion");

            _regionRepoMock.Verify(
            r => r.AddAsync(It.IsAny<Region>()),
            Times.Once
            );

        }


        // =========================
        // Méthode utilitaire (comme dans le cours)
        // =========================
        private List<Region> ListeRegionsAttendues()
        {
            return new List<Region>
            {
                new Region
                {
                    Name = "Montreal",
                    Latitude = 45.5,
                    Longitude = -73.6
                },
                new Region
                {
                    Name = "Quebec",
                    Latitude = 46.8,
                    Longitude = -71.2
                }
            };
        }

        [Fact]
        public async Task DeleteSelectedRegion_ShouldRemoveRegion()
        {
            // Arrange
            var region = new Region
            {
                Name = "Montreal",
                Latitude = 45,
                Longitude = -73
            };

            _regionRepoMock.Setup(r => r.GetAll())
                .Returns(new List<Region> { region });

            _regionRepoMock.Setup(r => r.DeleteAsync(It.IsAny<Region>()))
                .Returns(Task.CompletedTask);

            var vm = new MainViewModel(_regionRepoMock.Object);
            vm.SelectedRegion = region;

            // Act
            await vm.DeleteSelectedRegion();

            // Assert
            Assert.Empty(vm.Regions);
            _regionRepoMock.Verify(r => r.DeleteAsync(region), Times.Once);
        }

    }
}
