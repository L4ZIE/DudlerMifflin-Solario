import React, { useState } from 'react';
import './Cart.css';
import NavBar from "../NavBar/NavBar.tsx";

type CartItemType = {
    id: number;
    name: string;
    price: number;
    quantity: number;
};

// Cart Item Component
const CartItem: React.FC<{
    item: CartItemType;
    increment: (id: number) => void;
    decrement: (id: number) => void;
    removeItem: (id: number) => void;
}> = ({ item, increment, decrement, removeItem }) => {
    return (
        <div className="cart-item">
            <NavBar />
            <div className="cart-item__product">{item.name}</div>
            <div className="cart-item__price">{item.price} kr</div>
            <div className="cart-item__quantity">
                <button className="cart-item__button" onClick={() => decrement(item.id)}>-</button>
                <span>{item.quantity}</span>
                <button className="cart-item__button" onClick={() => increment(item.id)}>+</button>
            </div>
            <div className="cart-item__total">{item.price * item.quantity} kr</div>
            <button className="cart-item__remove" onClick={() => removeItem(item.id)}>Remove</button>
        </div>
    );
};

// Cart Component
const Cart: React.FC = () => {
    const [cartItems, setCartItems] = useState<CartItemType[]>([
        {id: 1, name: '50 sheets A4 white paper', price: 40, quantity: 1},
        {id: 2, name: '20 sheets A4 blue paper', price: 30, quantity: 1}
    ]);

    // Function to increment quantity
    const incrementQuantity = (id: number) => {
        setCartItems(prevItems =>
            prevItems.map(item =>
                item.id === id ? {...item, quantity: item.quantity + 1} : item
            )
        );
    };

    // Function to decrement quantity
    const decrementQuantity = (id: number) => {
        setCartItems(prevItems =>
            prevItems.map(item =>
                item.id === id && item.quantity > 1
                    ? { ...item, quantity: item.quantity - 1 }
                    : item
            )
        );
    };

    // Function to remove item from cart
    const removeItem = (id: number) => {
        setCartItems(prevItems => prevItems.filter(item => item.id !== id));
    };

    // Function to calculate total price
    const totalPrice = cartItems.reduce((total, item) => total + item.price * item.quantity, 0);

    return (
        <div className="cart-container">
            <h2 className="cart-title">Your cart items</h2>
            

            {cartItems.map(item => (
                <CartItem
                    key={item.id}
                    item={item}
                    increment={incrementQuantity}
                    decrement={decrementQuantity}
                    removeItem={removeItem}
                />
            ))}

            <div className="cart-footer">
                <h3>Total price: {totalPrice} kr</h3>
                <button className="checkout-button">Check-out</button>
            </div>
        </div>
    );
};

export default Cart;
