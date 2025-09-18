namespace Twiddle.DataAccess.Core;

internal interface IMapper<in TSource, out TTarget>
{
    public TTarget Map(TSource source);
}