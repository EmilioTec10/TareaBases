import React from 'react';
import './Menu.css';

const Menu = () => {
  // Array de objetos que contiene la información de los platos
  const menuItems = [
    { id: 1, name: 'Plato 1', price: 10, description: 'Descripción del Plato 1' },
    { id: 2, name: 'Plato 2', price: 15, description: 'Descripción del Plato 2' },
    { id: 3, name: 'Plato 3', price: 12, description: 'Descripción del Plato 3' },
    // Agrega más objetos de platos aquí
  ];

  return (
    <div className="menu-container">
      <h1>Menú del Restaurante</h1>
      <div className="menu-items">
        {menuItems.map((item) => (
          <div key={item.id} className="menu-item">
            <h2>{item.name}</h2>
            <p>Precio: ${item.price}</p>
            <p>{item.description}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Menu;
