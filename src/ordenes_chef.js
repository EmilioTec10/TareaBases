import React, { useState } from 'react';
import './ordenes_chef.css';

const Ordenes_Chef = () => {
  // Lista de pedidos
  const [orders, setOrders] = useState([
    { id: 1, dish: 'Pizza', assigned: false },
    { id: 2, dish: 'Pasta', assigned: false },
    { id: 3, dish: 'Sushi', assigned: false }
  ]);
  // Variable para guardar el nombre del plato seleccionado
  const [selectedDish, setSelectedDish] = useState('');
  // Variable para mostrar el mensaje "Has tomado un pedido"
  const [orderTaken, setOrderTaken] = useState(false);

  // Función para asignar un pedido al chef y guardar el nombre del plato seleccionado
  const assignOrder = (orderId, dishName) => {
    const updatedOrders = orders.filter(order => order.id !== orderId);
    setOrders(updatedOrders);
    setSelectedDish(dishName);
    setOrderTaken(true);
  };

  return (
    <div className="chefOrdersContainer">
      <h2>Pedidos Pendientes</h2>
      <hr className="divider" />
      <div className="ordersList">
        {orders.map(order => (
          <div key={order.id} className={`orderItem ${order.assigned ? 'assigned' : ''}`} onClick={() => assignOrder(order.id, order.dish)}>
            <span>{order.dish}</span>
          </div>
        ))}
      </div>
      {orderTaken && (
        <div className="messageContainer">
          <label>Has tomado un pedido: {selectedDish}</label>
        </div>
      )}
    </div>
  );
};

export default Ordenes_Chef;
