using GestionRecetas.Domain.Entities;
using GestionRecetas.Domain.Enums;
using GestionRecetas.Domain.ExcepcionesGenerales;
using GestionRecetas.Infraestructura.Persistencia;
using GestionRecetas.Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Moq;

public class RepositorioGenericoTests
{
    private readonly Mock<AplicacionDbContext> _mockDbContext;
    private readonly RepositorioGenerico<Receta> _repositorio;

    public RepositorioGenericoTests()
    {
        _mockDbContext = new Mock<AplicacionDbContext>(new DbContextOptions<AplicacionDbContext>());
        _repositorio = new RepositorioGenerico<Receta>(_mockDbContext.Object);
    }

    [Fact]
    public async Task AddAsync_ShouldAddEntity()
    {
        // Arrange
        var receta = Receta.CrearReceta(1, "Diego", 1, "Felipe Lopez", "6543265", "1 Inyeccion", "3 Dias", "No debe consumir lacteos", "Paracetamol", ViaAdministracion.Intramuscular, string.Empty, "Infeccion Respiratoria", DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")), DateTime.Parse("16/12/2024"));
        _mockDbContext.Setup(db => db.Set<Receta>().Add(It.IsAny<Receta>()));

        // Act
        var result = await _repositorio.AddAsync(receta);

        // Assert
        _mockDbContext.Verify(db => db.Set<Receta>().Add(It.Is<Receta>(r => r == receta)), Times.Once);
        _mockDbContext.Verify(db => db.SaveChangesAsync(default), Times.Once);
        Assert.Equal(receta, result);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllEntities()
    { // Arrange
        var recetas = new List<Receta> {
                                Receta.CrearReceta(1, "Diego", 1, "Felipe Lopez", "6543265", "1 Inyeccion Diaria", "3 Dias", "No debe consumir lacteos", "Paracetamol", ViaAdministracion.Intramuscular, string.Empty, "Infeccion Respiratoria", DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")), DateTime.Parse("16/12/2024")),
                                Receta.CrearReceta(2, "Felipe",1,  "Gonzalez Tabares", "6465464", "2 Pasta Diarias", "8 Días", "No tiene Restricciones", "Ibuprofeno", ViaAdministracion.Oral, "Debe seguir consumiendo verduras y frutas", "Enfermedad Gastro intestinal", DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")), DateTime.Parse("24/12/2024")),
                             };
        _mockDbContext.Setup(db => db.Set<Receta>().ToListAsync(default)).ReturnsAsync(recetas);
        // Act
        var result = await _repositorio.GetAllAsync();
        // Assert 
        Assert.Equal(recetas, result);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnEntity_WhenIdExists()
    {
        // Arrange
        var receta = Receta.CrearReceta(1, "Diego", 1, "Felipe Lopez", "6543265", "1 Inyeccion Diaria", "3 Dias", "No debe consumir lacteos", "Paracetamol", ViaAdministracion.Intramuscular, string.Empty, "Infeccion Respiratoria", DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")), DateTime.Parse("16/12/2024"));
        _mockDbContext.Setup(db => db.Set<Receta>().FindAsync(1)).ReturnsAsync(receta);

        // Act
        var result = await _repositorio.GetByIdAsync(1);

        // Assert
        Assert.Equal(receta, result);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldThrowNoHayDatosException_WhenIdDoesNotExist()
    {
        // Arrange
        _mockDbContext.Setup(db => db.Set<Receta>().FindAsync(It.IsAny<int>())).ReturnsAsync((Receta)null);

        // Act & Assert
        await Assert.ThrowsAsync<NoHayDatosException>(() => _repositorio.GetByIdAsync(1));
    }
}
