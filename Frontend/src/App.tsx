import React, { useState } from "react";
import './App.css';
import { FaShoppingCart } from 'react-icons/fa';
import NavBar from './NavBar/NavBar.tsx';
import NewProduct from './NewProduct/NewProduct.tsx';
import UpdateProduct from './UpdateProduct/UpdateProduct.tsx';
import { BrowserRouter as Router, Route, Routes, useNavigate } from 'react-router-dom';
import OrderHistory from "./OrderHistory/OrderHistory.tsx";
import YourOrderHistory from "./YourOrderHistory/YourOrderHistory.tsx";
    

type Product = {
    id: number;
    name: string;
    price: number;
    quantity: number;
};

const App: React.FC = () => {
    const [products, setProducts] = useState<Product[]>([
        { id: 1, name: "50 sheets A4 white paper", price: 40, quantity: 1 },
        { id: 2, name: "20 sheets A4 blue paper", price: 30, quantity: 1 },
        { id: 3, name: "100 sheets A4 mixed color paper", price: 100, quantity: 1 },
        { id: 4, name: "50 sheets A4 white paper", price: 40, quantity: 1 },
        { id: 5, name: "20 sheets A4 blue paper", price: 30, quantity: 1 },
        { id: 6, name: "100 sheets A4 mixed color paper", price: 100, quantity: 1 },
        { id: 7, name: "50 sheets A4 white paper", price: 40, quantity: 1 },
        { id: 8, name: "20 sheets A4 blue paper", price: 30, quantity: 1 },
        { id: 9, name: "100 sheets A4 mixed color paper", price: 100, quantity: 1 },        
    ]);

    const [searchTerm, setSearchTerm] = useState(""); 
    const [filter, setFilter] = useState<string>(""); 
    const navigate = useNavigate();

    // Filter products based on search term
    const filteredProducts = products
        .filter((product) =>
            product.name.toLowerCase().includes(searchTerm.toLowerCase())
        )
        .sort((a, b) => {
            if (filter === "priceLowHigh") return a.price - b.price;
            if (filter === "priceHighLow") return b.price - a.price;
            return 0;
        });

    // Handle quantity update
    const updateQuantity = (id: number, increment: boolean) => {
        setProducts((prevProducts) =>
            prevProducts.map((product) =>
                product.id === id
                    ? { ...product, quantity: product.quantity + (increment ? 1 : -1) }
                    : product
            )
        );
    };

    // Handle search input change
    const handleSearchChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setSearchTerm(event.target.value);
    };

    // Handle filter change
    const handleFilterChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        setFilter(event.target.value);
    };

    // Navigate to Update Product page
    const handleUpdateProduct = (product: Product) => {
        navigate('/update-product', { state: { product, isEdit: true } });
    };

    return (
        <div className="app">
            <NavBar/>

            {/* Search and Filter Section */}
            <div className="header">
                <input
                    type="text"
                    placeholder="Search"
                    value={searchTerm}
                    onChange={handleSearchChange}
                    className="search-bar"
                />
                <select value={filter} onChange={handleFilterChange} className="filter-dropdown">
                    <option value="">Sort By</option>
                    <option value="priceLowHigh">Price: Low to High</option>
                    <option value="priceHighLow">Price: High to Low</option>
                </select>
                <button onClick={() => navigate('/new-product')} className="add-product-button">
                    Add product
                </button>
            </div>

            {/* Product Table */}
            <div className="product-table">
                {filteredProducts.length > 0 ? (
                    filteredProducts.map((product) => (
                    <div className="product-row" key={product.id}>
                        <div className="product-name">
                            {product.name}
                            <div className="actions">
                                <span className="action-link" onClick={() => handleUpdateProduct(product)}>Update</span>
                                <span className="action-link">Delete</span>
                            </div>
                        </div>
                        <div className="product-price">{product.price} kr</div>
                        <div className="product-quantity">
                            <button onClick={() => updateQuantity(product.id, false)}
                                    disabled={product.quantity <= 1}>-
                            </button>
                            <span>{product.quantity}</span>
                            <button onClick={() => updateQuantity(product.id, true)}>+</button>
                        </div>
                        <div className="add-to-cart">
                            <button className="cart-button">
                                <FaShoppingCart/>
                            </button>
                        </div>
                    </div>
                ))
                ): (
                    <div>No products found</div>
                )}
            </div>
        </div>
    );
};

const MainApp = () => (
    <Router>
        <Routes>
            <Route path="/" element={<App />} />
            <Route path="/new-product" element={<NewProduct />} />
            <Route path="/update-product" element={<UpdateProduct />} />
            <Route path={"/order-history"} element={<OrderHistory />} />
            <Route path={"/your-order-history"} element={<YourOrderHistory />} />
            
        </Routes>
    </Router>
);

export default MainApp;
