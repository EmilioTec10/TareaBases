import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Home from './home';
import Login from './login';
import './App.css';
import Menu from './menu';
import Platos from './platos';
import Vista_Admin from './vista_admin'; 
import Reportes from './reportes'; // Importa el componente Reportes
import Login_Chef from './login_chef'; // Importa el componente Login_Chef
import Vista_Chef from './vista_chef';
import Ordenes_Chef from './ordenes_chef';
import Control_Pedidos from './control_pedidos'; // Importa el componente Control_Pedidos

import { useEffect, useState } from 'react';

function App() {
  const [loggedIn, setLoggedIn] = useState(false);
  const [email, setEmail] = useState('');

  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home email={email} loggedIn={loggedIn} setLoggedIn={setLoggedIn} />} />
          <Route path="/login" element={<Login setLoggedIn={setLoggedIn} setEmail={setEmail} />} />
          <Route path="/menu" element={<Menu loggedIn={loggedIn} email={email} />} />
          <Route path="/platos" element={<Platos loggedIn={loggedIn} email={email} />} />
          <Route path="/vista_admin" element={<Vista_Admin />} />
          <Route path="/reportes" element={<Reportes />} />
          <Route path="/login_chef" element={<Login_Chef setLoggedIn={setLoggedIn} setEmail={setEmail} />} />
          <Route path="/vista_chef" element={<Vista_Chef />} /> {/* Nueva ruta para Vista_Chef */}
          <Route path="/ordenes_chef" element={<Ordenes_Chef />} /> {/* Nueva ruta para Ordenes_Chef */}
          <Route path="/control_pedidos" element={<Control_Pedidos />} /> {/* Nueva ruta para Control_Pedidos */}
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
