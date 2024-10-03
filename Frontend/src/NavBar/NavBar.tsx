import React from 'react';
import './NavBar.css';
import { FaShoppingCart } from 'react-icons/fa';  

const NavBar: React.FC = () => {
    return (
        <nav className="navbar">
            <div className="nav-left">
                <button className="nav-button">Home</button>
                <button className="nav-button">Order History</button>
                <button className="nav-button">Your Order History</button>
            </div>
            <div className="nav-right">
                <button className="cart-button">
                    <FaShoppingCart />
                </button>
            </div>
        </nav>
    );
}

export default NavBar;
