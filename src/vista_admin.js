import React from 'react';
import './vista_admin.css'; // Importar estilos CSS

const Vista_Admin = () => {
  const handleButtonClick = (path) => {
    window.location.href = path;
  };

  return (
    <div className="adminContainer">
      <h1>Bienvenido a la Vista de Administrador</h1>
      <div className="buttonContainer">
        <button className="adminButton" onClick={() => handleButtonClick('/platos')}>1. Gestión de Tipos de Platos</button>
        <button className="adminButton" onClick={() => handleButtonClick('/menu')}>2. Gestión del Menú</button>
        <button className="adminButton" onClick={() => handleButtonClick('/reportes')}>3. Vista de Reportes</button>
      </div>
    </div>
  );
};

export default Vista_Admin;
