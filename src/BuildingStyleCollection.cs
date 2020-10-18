using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Cyotek.SkylineGenerator
{
  [JsonArray]
  internal class BuildingStyleCollection : Collection<BuildingStyle>, INotifyCollectionChanged, INotifyPropertyChanged
  {
    #region Methods

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>
    /// A string that represents the current object.
    /// </returns>
    public override string ToString()
    {
      return string.Concat(this.Count.ToString(), " styles");
    }

    /// <summary>
    /// Removes all elements from the <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
    /// </summary>
    protected override void ClearItems()
    {
      base.ClearItems();

      this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    /// <summary>
    /// Inserts an element into the <see cref="T:System.Collections.ObjectModel.Collection`1"/> at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param><param name="item">The object to insert. The value can be null for reference types.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.-or-<paramref name="index"/> is greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count"/>.</exception>
    protected override void InsertItem(int index, BuildingStyle item)
    {
      item.PropertyChanged += this.ChildPropertyChangedHandler;

      base.InsertItem(index, item);

      this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new[]
                                                                                                       {
                                                                                                         item
                                                                                                       }));
    }

    /// <summary>
    /// Raises the <see cref="CollectionChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
      this.CollectionChanged?.Invoke(this, e);
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Removes the element at the specified index of the <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
    /// </summary>
    /// <param name="index">The zero-based index of the element to remove.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.-or-<paramref name="index"/> is equal to or greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count"/>.</exception>
    protected override void RemoveItem(int index)
    {
      BuildingStyle item;

      item = this.Items[index];
      item.PropertyChanged -= this.ChildPropertyChangedHandler;

      base.RemoveItem(index);

      this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, new[]
                                                                                                          {
                                                                                                            item
                                                                                                          }));
    }

    private void ChildPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
    {
      this.OnPropertyChanged(e.PropertyName);
    }

    #endregion

    #region INotifyCollectionChanged Interface

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    #endregion

    #region INotifyPropertyChanged Interface

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion
  }
}
