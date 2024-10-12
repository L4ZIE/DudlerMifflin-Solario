import React, {useEffect, useState} from "react";
import './App.css';
import { FaShoppingCart } from 'react-icons/fa';
import NavBar from './NavBar/NavBar.tsx';
import NewProduct from './NewProduct/NewProduct.tsx';
import UpdateProduct from './UpdateProduct/UpdateProduct.tsx';
import {BrowserRouter as Router, Route, Routes, useLocation, useNavigate} from 'react-router-dom';
import OrderHistory from "./OrderHistory/OrderHistory.tsx";
import YourOrderHistory from "./YourOrderHistory/YourOrderHistory.tsx";
import Cart from "./Cart/Cart";
    

type Product = {
    paperId: number;
    paperName: string;
    quantity: number;
    price: number;
};

const App: React.FC = () => {
    const [products, setProducts] = useState<Product[]>([
        { paperId: 1, paperName: "50 sheets A4 white paper", price: 40, quantity: 1 },
        { paperId: 2, paperName: "20 sheets A4 blue paper", price: 30, quantity: 1 },
        { paperId: 3, paperName: "100 sheets A4 mixed color paper", price: 100, quantity: 1 },
               
    ]);

    const [searchTerm, setSearchTerm] = useState(""); 
    const [filter, setFilter] = useState<string>(""); 
    const [successMessage, setSuccessMessage] = useState<string>("");
    const navigate = useNavigate();
    const location = useLocation();
    
    // Fetch papers from the backend API when the component mounts
    useEffect(() => {
        // Check if there is a success message from the state
        if (location.state?.successMessage) {
            setSuccessMessage(location.state.successMessage);
            // clear the state message after showing it once
            window.history.replaceState({}, document.title);
        }
        const fetchProducts = async () => {
            try {
                const response = await fetch("http://localhost:5173/api/Paper");
                if (!response.ok) {
                    throw new Error(`HTTP error! status: ${response.status}`);
                }
                const data = await response.json();
                setProducts(data);
            } catch (error) {
                console.error("Error fetching products", error);
            }
        };
        fetchProducts();
    }, [location.state]); // refetch when redirected from NewProduct
    

    // Filter products based on search term
    const filteredProducts = products
        .filter((product) =>
            product.paperName.toLowerCase().includes(searchTerm.toLowerCase())
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
                product.paperId === id
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

            {/* Show success message after creating a product */}
            {successMessage && <div className="success-message">{successMessage}</div>}

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
                    <div className="product-row" key={product.paperId}>
                        <div className="product-name">
                            {product.paperName}
                            <div className="actions">
                                <span className="action-link" onClick={() => handleUpdateProduct(product)}>Update</span>
                                <span className="action-link">Delete</span>
                            </div>
                        </div>
                        <div className="product-price">{product.price} kr</div>
                        <div className="product-quantity">
                            <button onClick={() => updateQuantity(product.paperId, false)}
                                    disabled={product.quantity <= 1}>-
                            </button>
                            <span>{product.quantity}</span>
                            <button onClick={() => updateQuantity(product.paperId, true)}>+</button>
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
            <Route path={"/cart"} element={<Cart />} />/    
        </Routes>
    </Router>
);

export default MainApp;
