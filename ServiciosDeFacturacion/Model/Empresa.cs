public class Empresa {

    public string? NombreEmpresa {get; set;}
    public int RutEmpresa {get; set;}

    public string? GiroEmpresa {get; set;}

    public decimal TotalVentas {get; set;}
    public decimal MontoVentas {get; set;}

    public decimal MontoIva => (MontoVentas * (decimal)0.19);

    public decimal MontoUtilidades => MontoVentas - MontoIva;

    public decimal Mes => TotalVentas + MontoUtilidades; // Restamos 10,000 por mes
}