import React from 'react';
import './OrderHistory.css';
import NavBar from "../NavBar/NavBar.tsx";

type Order = {
    orderNumber: number;
    customer: string;
    orderDate: string;
    deliveryDate: string;
    status: string;
    totalAmount: string;
};

const orders: Order[] = [
    { orderNumber: 1001, customer: 'Wade Warren', orderDate: '01.09.2024', deliveryDate: '03.09.2024', status: 'pending', totalAmount: '220 kr' },
    { orderNumber: 1002, customer: 'Esther Howard', orderDate: '01.09.2024', deliveryDate: '04.09.2024', status: 'pending', totalAmount: '360 kr' },
    { orderNumber: 1003, customer: 'Jenny Wilson', orderDate: '03.09.2024', deliveryDate: '05.09.2024', status: 'pending', totalAmount: '130 kr' },
    { orderNumber: 1004, customer: 'Jacob Jones', orderDate: '04.09.2024', deliveryDate: '05.09.2024', status: 'pending', totalAmount: '680 kr' },
    { orderNumber: 1005, customer: 'Albert Flores', orderDate: '06.09.2024', deliveryDate: '08.09.2024', status: 'pending', totalAmount: '1240 kr' },
    { orderNumber: 1006, customer: 'Theresa Webb', orderDate: '07.09.2024', deliveryDate: '09.09.2024', status: 'pending', totalAmount: '820 kr' },
    { orderNumber: 1007, customer: 'Wade Warren', orderDate: '01.09.2024', deliveryDate: '03.09.2024', status: 'pending', totalAmount: '220 kr' },
    { orderNumber: 1008, customer: 'Esther Howard', orderDate: '01.09.2024', deliveryDate: '04.09.2024', status: 'pending', totalAmount: '360 kr' },
    { orderNumber: 1009, customer: 'Jenny Wilson', orderDate: '03.09.2024', deliveryDate: '05.09.2024', status: 'pending', totalAmount: '130 kr' },
    { orderNumber: 1010, customer: 'Jacob Jones', orderDate: '04.09.2024', deliveryDate: '05.09.2024', status: 'pending', totalAmount: '680 kr' },
    { orderNumber: 1011, customer: 'Albert Flores', orderDate: '06.09.2024', deliveryDate: '08.09.2024', status: 'pending', totalAmount: '1240 kr' },
    { orderNumber: 1012, customer: 'Theresa Webb', orderDate: '07.09.2024', deliveryDate: '09.09.2024', status: 'pending', totalAmount: '820 kr' },
    { orderNumber: 1013, customer: 'Esther Howard', orderDate: '01.09.2024', deliveryDate: '04.09.2024', status: 'pending', totalAmount: '360 kr' },
    { orderNumber: 1014, customer: 'Jenny Wilson', orderDate: '03.09.2024', deliveryDate: '05.09.2024', status: 'pending', totalAmount: '130 kr' },
    { orderNumber: 1015, customer: 'Jacob Jones', orderDate: '04.09.2024', deliveryDate: '05.09.2024', status: 'pending', totalAmount: '680 kr' },
    { orderNumber: 1016, customer: 'Albert Flores', orderDate: '06.09.2024', deliveryDate: '08.09.2024', status: 'pending', totalAmount: '1240 kr' },
    { orderNumber: 1017, customer: 'Theresa Webb', orderDate: '07.09.2024', deliveryDate: '09.09.2024', status: 'pending', totalAmount: '820 kr' },
];

const OrderHistory: React.FC = () => {
    return (
        <div className="order-history">
            <NavBar />
            
            <h1>Order history</h1>
            <button className="change-status-btn">Change status</button>
            <table className="order-history-table">
                <thead>
                <tr>
                    <th>Order number</th>
                    <th>Customer</th>
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
                        <td>{order.customer}</td>
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

export default OrderHistory;
