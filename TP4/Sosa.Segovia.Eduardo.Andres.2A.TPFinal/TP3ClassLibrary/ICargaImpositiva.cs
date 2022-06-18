namespace TP3ClassLibrary
{
    /// <summary>
    /// Interface que te permite agregar funciones de cargas impositivas, se usa en facturacion
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ICargaImpositiva<T>
    {
        double CalcularBonificaciones(T comprador);
        double CalcularImpuesto(T comprador);
    }
}
