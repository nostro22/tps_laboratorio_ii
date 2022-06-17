namespace TP3ClassLibrary
{
    interface ICargaImpositiva<T>
    {
        double CalcularBonificaciones(T comprador);
        double CalcularImpuesto(T comprador);
    }
}
