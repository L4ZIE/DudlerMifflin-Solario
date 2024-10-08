import React from 'react';
import './YourOrderHistory.css';
import NavBar from "../NavBar/NavBar.tsx";

type Order = {
    orderNumber: number;
    orderDate: string;
    deliveryDate: string;
    status: string;
    totalAmount: string;
};

const orders: Order[] = [
    { orderNumber: 1001, orderDate: '01.09.2024', deliveryDate: '03.09.2024', status: 'pending', totalAmount: '220 kr' },
    { orderNumber: 1002, orderDate: '01.09.2024', deliveryDate: '04.09.2024', status: 'pending', totalAmount: '360 kr' },
    { orderNumber: 1003, orderDate: '03.09.2024', deliveryDate: '05.09.2024', status: 'pending', totalAmount: '130 kr' },
    { orderNumber: 1004, orderDate: '04.09.2024', deliveryDate: '05.09.2024', status: 'pending', totalAmount: '680 kr' },
    { orderNumber: 1005, orderDate: '06.09.2024', deliveryDate: '08.09.2024', status: 'pending', totalAmount: '1240 kr' },
    { orderNumber: 1006, orderDate: '07.09.2024', deliveryDate: '09.09.2024', status: 'pending', totalAmount: '820 kr' },
    { orderNumber: 1007, orderDate: '01.09.2024', deliveryDate: '03.09.2024', status: 'pending', totalAmount: '220 kr' },
    { orderNumber: 1008, orderDate: '01.09.2024', deliveryDate: '04.09.2024', status: 'pending', totalAmount: '360 kr' },
    { orderNumber: 1009, orderDate: '03.09.2024', deliveryDate: '05.09.2024', status: 'pending', totalAmount: '130 kr' },
    { orderNumber: 1010, orderDate: '04.09.2024', deliveryDate: '05.09.2024', status: 'pending', totalAmount: '680 kr' },
    { orderNumber: 1011, orderDate: '06.09.2024', deliveryDate: '08.09.2024', status: 'pending', totalAmount: '1240 kr' },
    { orderNumber: 1012, orderDate: '07.09.2024', deliveryDate: '09.09.2024', status: 'pending', totalAmount: '820 kr' },
];

const YourOrderHistory: React.FC = () => {
    return (
        <div className="your-order-history">
            <NavBar />
            <h1>Your Order History</h1>
            <table className="your-order-history-table">
                <thead>
                <tr>
                    <th>Order number</th>
                    <th>Order date</th>
                    <th>Delivery Date</th>
                    <th>Status</th>
                    <th>Total amount</th>
                </tr>
                </thead>
                <tbody>
                {orders.map((order) => (
                    <tr key={order.orderNumber}>
                        <td>{order.orderNumber}</td>
                        <td>{order.orderDate}</td>
                        <td>{order.deliveryDate}</td>
                        <td className={order.status === 'pending' ? 'pending-status' : ''}>{order.status}</td>
                        <td>{order.totalAmount}</td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
};

export default YourOrderHistory;
