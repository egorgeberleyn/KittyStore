﻿using KittyStore.Domain.CatAggregate.ValueObjects;
using KittyStore.Domain.Common.Models;
using KittyStore.Domain.CustomerAggregate.ValueObjects;
using KittyStore.Domain.ShopCartAggregate.Entities;
using KittyStore.Domain.ShopCartAggregate.ValueObjects;

namespace KittyStore.Domain.ShopCartAggregate;

public sealed class ShopCart : AggregateRoot<ShopCartId>
{
    private readonly List<ShopCartItem> _items = new();
    
    
    public CustomerId CustomerId { get; }

    public IReadOnlyList<ShopCartItem> ShopCartItems => _items.AsReadOnly();

    public int TotalItems => _items.Count;

    public ShopCart(ShopCartId id, CustomerId customerId) : base(id)
    {
        CustomerId = customerId;
    }

    public ShopCart Create(CustomerId customerId) => 
        new (ShopCartId.CreateUnique(), customerId);
    
    public void AddItem(ShopCartItemId shopCartItemId, decimal unitPrice, CatId catId)
    {
        if (ShopCartItems.Any(i => i.Id.Value == shopCartItemId.Value)) return; //do it exception 
        _items.Add(ShopCartItem.Create(unitPrice, catId, Id));
    }

    public void ClearShopCart() => _items.Clear();
}