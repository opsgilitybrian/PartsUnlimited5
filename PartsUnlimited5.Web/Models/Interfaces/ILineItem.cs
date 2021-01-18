namespace PartsUnlimited5.Web.Models.Interfaces
{
    public interface ILineItem
	{
		int Count { get; }

		Product Product { get; }
	}
}
