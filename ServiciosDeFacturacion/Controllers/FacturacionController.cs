using Microsoft.AspNetCore.Mvc;

public class Facturacion : ControllerBase {

    public Cliente[] DatosCliente = new Cliente[]{
        
        new Cliente{NombreCliente="Pedro", ApellidoCliente="Gaete", EdadCliente=54, RutCliente=53288421},
        new Cliente{NombreCliente="Marcelino", ApellidoCliente="Muñoz", EdadCliente=23, RutCliente=19528964},
        new Cliente{NombreCliente="Edson", ApellidoCliente="Roldan", EdadCliente=26, RutCliente=19240588},
    };

    public Empresa[] DatosEmpresa = new Empresa[]{

        new Empresa {NombreEmpresa="Noniyon",RutEmpresa=99288,GiroEmpresa="Publicidad",TotalVentas=300,MontoVentas=3000000},
        new Empresa {NombreEmpresa="Falabella",RutEmpresa=1,GiroEmpresa="Retail",TotalVentas=300,MontoVentas=3000000},
        new Empresa {NombreEmpresa="Jumbo",RutEmpresa=2,GiroEmpresa="Supermercado",TotalVentas=300,MontoVentas=3000000}
    };

    [HttpGet]
    [Route("cliente")]

    public IActionResult listarCliente(){
        try{

            if(DatosCliente != null){

                for(int i=0; i< DatosCliente.Length; i++){
                    Console.WriteLine(DatosCliente[i]);
                }
                return StatusCode(200,DatosCliente);
            }else{

                return StatusCode(404,"los datos no se han podido actualizar");
            }
            

        }catch(Exception ex){

                return StatusCode(401,"El sistema no ha permitido la peticion"+ex);
        }
     
    }

    [HttpGet]
    [Route("Empresa")]

    public IActionResult listarEmpresa(){

        try{

            if(DatosEmpresa != null){

                for(int e=0; e< DatosEmpresa.Length; e++){
                    Console.WriteLine(DatosEmpresa[e]);
                }

                return StatusCode(200,DatosEmpresa);
            }else{

                return StatusCode(401,"los datos de empresa no se ha podido actualizar");
            }


        }catch(Exception ex){

            return StatusCode(404,"el sistema no se ha permitido "+ex);


        }
    }

    [HttpGet]
    [Route("Empresa/{RutEmpresa}")]

    public IActionResult ListarDatosEmpresas(int rut){
        try{

            if(rut > 0 && rut <= DatosEmpresa.Length){

                return StatusCode(200,DatosEmpresa[rut-1]);
            }else{

                return StatusCode(401,"No se encontro datos de empresas");
            }


        }catch(Exception ex){

            return StatusCode(500,"Error del servicios"+ex);


        }
    }


    [HttpPost]
    [Route("Empresa/{RutEmpresa}")]

    public IActionResult ActualizarDatos([FromBody]Empresa empresas){
        
        try{

            return StatusCode(200,DatosEmpresa);

        }catch(Exception ex){

            return StatusCode(400, "No se ha podido crear y guardar datos de la empresa"+ex);

        }
    }

    [HttpPut]
    [Route("Empresa/{RutEmpresa}")]

    public IActionResult EditarDatos(int rut, [FromBody] Empresa Empresas){

        try{

            if(rut > 0 && rut == Empresas.RutEmpresa){

                DatosEmpresa[rut-1].NombreEmpresa=Empresas.NombreEmpresa;
                DatosEmpresa[rut-1].GiroEmpresa=Empresas.GiroEmpresa;
                DatosEmpresa[rut-1].TotalVentas=Empresas.TotalVentas;

                return StatusCode(200,DatosEmpresa);
            }else{

                return StatusCode(404,"Intentelo de nuevo");
            }


        }catch(Exception ex){

            return StatusCode(500,"Error del servidor"+ex);
        }
    }

    [HttpDelete]
    [Route("Empresa/{RutEmpresa}")]

    

    public IActionResult Eliminar(int RutEmpresa){

        try{
            if(RutEmpresa >0 && RutEmpresa <= DatosEmpresa.Length){

                DatosEmpresa[RutEmpresa-1] = null;
                return StatusCode(200,"Eliminado exitosamente");
            }else{

                return StatusCode(404,"no se ha logrado eliminar");
            }

        }catch(Exception ex){

            return StatusCode(500,"Error de sistema"+ex);


        }
    }
}