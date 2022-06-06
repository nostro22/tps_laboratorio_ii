namespace TP3ClassLibrary
{
    interface ICargaImpositiva<T>
    {
        float CalcularBonificaciones(T comprador);
        float CalcularImpuesto(T comprador);
    }
}
