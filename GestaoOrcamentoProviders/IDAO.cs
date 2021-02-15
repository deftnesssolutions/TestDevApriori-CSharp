using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GO.Providers
{
    /*######
    * Programa:Interface DAO PARA CRUD de entidades en Banco de Datos
    * Autor: GUSTAVO OVELAR
    * Fecha: 24/01/2021
   #####*/

    //Interface que sirve de base para la manipulación de datos de las Tablas en el banco de datos con utilización del colector de basura(Garbage Collector)
    //que sera el encargado de limpiar qualquier objeto sin uso que este utilizando  memoria
    public interface IDAO<T>:IDisposable
        where T: class,new()
    {        
        IEnumerable<T> All();//metodo para retornar todos los registros
        T FindOrDefault(params object[] keys);//metodo para retornar un registro
        string CurremRegVal();//Metodo para retornar cantidad de resgistros
        //IEnumerable<T> filtroPorDescricao(string descricao) //Busqueda por descripción;
        T Insert(T model);//metodo para insertar registro
        void Update(T model);//metodo para actualizar registro
        bool Delete(T model);//metodo para eliminar registro 

    }
}
