namespace TP3ClassLibrary
{
    /// <summary>
    /// Interface que te permite agregar funciones de cargas impositivas, se usa en facturacion
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ICargaImpositiva<T>
    {
        decimal CalcularBonificaciones(T comprador);
        decimal CalcularImpuesto(T comprador);
    }
}
