import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Home from './home';
import Login from './login';
import './App.css';
import Menu from './menu';
import Platos from './platos';
import Vista_Admin from './vista_admin'; 
import Reportes from './reportes'; // Importa el componente Reportes
import Login_Chef from './login_chef'; // Importa el componente Login_Chef

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
          <Route path="/login_chef" element={<Login_Chef setLoggedIn={setLoggedIn} setEmail={setEmail} />} /> {/* Nueva ruta para Login_Chef */}
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
