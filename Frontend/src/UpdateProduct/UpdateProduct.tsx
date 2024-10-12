import React, {useEffect, useState} from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import './UpdateProduct.css';
import NavBar from "../NavBar/NavBar.tsx";

const UpdateProduct: React.FC = () => {
    const navigate = useNavigate();
    const location = useLocation();
    const product = location.state?.product || {};
    
    const [productName, setProductName] = useState<string>('');
    const [price, setPrice] = useState<number | string>('');
    const [discontinued, setDiscontinued] = useState<string>('');
    const [stock, setStock] = useState<number | string>('');
    const [customProperties, setCustomProperties] = useState<string>('');

    useEffect(() => {
        if (!location.state?.isEdit) {
            navigate('/');
        }
    }, [location, navigate]);
    
    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        const updatedProduct = {
            paperId: product.paperId,
            paperName: productName,
            price: Number(price),
            discontinued: discontinued === 'yes',
            stock: Number(stock),
            customProperties,
        };

        try {
            const response = await fetch(`http://localhost:5173/api/Paper/${product.paperId}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(updatedProduct),
            });

            if (response.ok) {
                navigate('/', { state: { successMessage: 'Product updated successfully!' } });
            } else {
                console.error("Failed to update product");
            }
        } catch (error) {
            console.error("Error:", error);
        }
    };

    return (
        <div className="update-product">
            <NavBar/>
            
            <h1 className="title">Update product</h1>
            <form className="product-form" onSubmit={handleSubmit}>
                {/* Product Name */}
                <div className="form-group">
                    <label>Name of the product</label>
                    <input
                        type="text"
                        value={productName}
                        onChange={(e) => setProductName(e.target.value)}
                        className="input-field1"
                        placeholder="Enter product name"
                    />
                </div>

                {/* Price */}
                <div className="form-group">
                    <label>Price</label>
                    <input
                        type="number"
                        value={price}
                        onChange={(e) => setPrice(e.target.value)}
                        className="input-field"
                        placeholder="Enter price"
                    />
                    <span className="currency-label"> kr</span>
                </div>

                {/* Discontinued */}
                <div className="form-group">
                    <label>Discontinued</label>
                    <div className="checkbox-group">
                        <label>
                            <input
                                type="radio"
                                value="yes"
                                checked={discontinued === 'yes'}
                                onChange={() => setDiscontinued('yes')}
                            />
                            Yes
                        </label>
                        <label>
                            <input
                                type="radio"
                                value="no"
                                checked={discontinued === 'no'}
                                onChange={() => setDiscontinued('no')}
                            />
                            No
                        </label>
                    </div>
                </div>

                {/* Stock */}
                <div className="form-group">
                    <label>Stock</label>
                    <input
                        type="number"
                        value={stock}
                        onChange={(e) => setStock(e.target.value)}
                        className="input-field"
                        placeholder="Enter stock quantity"
                    />
                </div>

                {/* Custom Properties */}
                <div className="form-group">
                    <label>
                        Custom properties <span className="optional-label">*Optional</span>
                    </label>
                    <input
                        type="text"
                        value={customProperties}
                        onChange={(e) => setCustomProperties(e.target.value)}
                        className="input-field"
                        placeholder="Enter custom properties"
                    />
                </div>

                {/* Submit Button */}
                <button type="submit" className="submit-button">Save</button>
            </form>
        </div>
    );
};

export default UpdateProduct;