// App.tsx
import React, { useState } from "react";
import './App.css';

// Product type
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
    ]);

    const [searchTerm, setSearchTerm] = useState(""); // Search term state
    const [filter, setFilter] = useState<string>("recommended"); // Filter state
   // const [newProduct, setNewProduct] = useState<Product>({ id: 0, name: "", price: 0, quantity: 1 });
  //  const [isEditing, setIsEditing] = useState<number | null>(null);

    // Filter products based on search term
    const filteredProducts = products.filter((product) =>
        product.name.toLowerCase().includes(searchTerm.toLowerCase())
    );

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

    return (
        <div className="app">
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
                    <option value="recommended">Recommended</option>
                    <option value="priceLowHigh">Price: Low to High</option>
                    <option value="priceHighLow">Price: High to Low</option>
                </select>
                <button className="add-product-button">Add product</button>
            </div>

            {/* Product Table */}
            <div className="product-table">
                {filteredProducts.map((product) => (
                    <div className="product-row" key={product.id}>
                        <div className="product-name">
                            {product.name}
                            <div className="actions">
                                <span className="action-link">Update</span>
                                <span className="action-link">Delete</span>
                            </div>
                        </div>
                        <div className="product-price">{product.price} kr</div>
                        <div className="product-quantity">
                            <button onClick={() => updateQuantity(product.id, false)} disabled={product.quantity <= 1}>-</button>
                            <span>{product.quantity}</span>
                            <button onClick={() => updateQuantity(product.id, true)}>+</button>
                        </div>
                        <div className="add-to-cart">
                            <button className="cart-button">
                                <i className="fas fa-shopping-cart"></i>
                            </button>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default App;
