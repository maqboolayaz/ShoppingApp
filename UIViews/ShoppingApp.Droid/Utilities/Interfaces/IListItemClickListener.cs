namespace ShoppingApp.Droid.Utilities.Interfaces
{
    public interface IListItemClickListener<in T> where T : class
    {
        void ItemSelected(T item);
    }
}