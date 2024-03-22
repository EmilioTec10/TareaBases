import React, { useState, useEffect } from 'react';
import './Menu.css';

const Platos = () => {
  // Estado para almacenar los elementos del menú
  const [menuItems, setMenuItems] = useState([]);
  // Estado para el nuevo plato a agregar
  const [newMenuItem, setNewMenuItem] = useState({ name: '', price: '', calories: '', type: '' });

  // Función para manejar cambios en el formulario
  const handleChange = (e) => {
    const { name, value } = e.target;
    setNewMenuItem({ ...newMenuItem, [name]: value });
  };

  // Función para manejar envío del formulario (agregar plato)
  const handleSubmit = (e) => {
    e.preventDefault();
    // Agregar nuevo plato al estado
    setMenuItems([...menuItems, newMenuItem]);
    // Limpiar el formulario
    setNewMenuItem({ name: '', price: '', calories: '', type: '' });
  };

  // Al cargar el componente, recuperar los elementos del menú del almacenamiento local
  useEffect(() => {
    const savedMenuItems = JSON.parse(localStorage.getItem('menuItems'));
    if (savedMenuItems) {
      setMenuItems(savedMenuItems);
    }
  }, []);

  // Al cambiar los elementos del menú, guardarlos en el almacenamiento local
  useEffect(() => {
    localStorage.setItem('menuItems', JSON.stringify(menuItems));
  }, [menuItems]);

  return (
    <div className="platos-container">
      <h1>Nuevo Plato</h1>
      <form onSubmit={handleSubmit} className="platos-form">
        <input type="text" name="name" placeholder="Nombre del plato" value={newMenuItem.name} onChange={handleChange} required />
        <input type="number" name="price" placeholder="Precio" value={newMenuItem.price} onChange={handleChange} required />
        <input type="number" name="calories" placeholder="Calorías" value={newMenuItem.calories} onChange={handleChange} required />
        <input type="text" name="type" placeholder="Tipo" value={newMenuItem.type} onChange={handleChange} required />
        <button type="submit" className="submit-button">Agregar Plato</button>
      </form>
      <div className="menu-items-container">
        {menuItems.map((item, index) => (
          <div key={index} className="menu-item">
            <h3>{item.name}</h3>
            <p>Precio: ${item.price}</p>
            <p>Calorías: {item.calories}</p>
            <p>Tipo: {item.type}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Platos;
