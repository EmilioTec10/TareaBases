import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [emailError, setEmailError] = useState('');
  const [passwordError, setPasswordError] = useState('');
  const navigate = useNavigate();

  const onButtonClick = async () => {
    setEmailError('');
    setPasswordError('');

    let isValid = true;

    // Validación del correo electrónico
    if (!email) {
      setEmailError('Please enter your email');
      isValid = false;
    } else if (!/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/.test(email)) {
      setEmailError('Please enter a valid email');
      isValid = false;
    }

    // Validación de la contraseña
    if (!password) {
      setPasswordError('Please enter a password');
      isValid = false;
    } else if (password.length < 8) {
      setPasswordError('The password must be 8 characters or longer');
      isValid = false;
    }

    // Si alguna validación falla, detener el proceso y mostrar mensajes de error
    if (!isValid) {
      return;
    }

    try {
      // Cargar el archivo JSON local
      const response = await fetch('/database.json');
      const jsonData = await response.json();

      // Realizar la validación comparando los datos ingresados por el usuario
      // con los datos del archivo JSON
      const isValidUser = jsonData.users.some(user => user.email === email && user.password === password);
      
      if (isValidUser) {
        // Si la validación es exitosa, redirige al usuario a la página de menú
        navigate('/menu');
      } else {
        // Si la validación falla, muestra un mensaje de error
        setEmailError('Invalid email or password');
        setPassword('');
      }
    } catch (error) {
      console.error('Error loading JSON file:', error);
    }
  };

  return (
    <div className="mainContainer">
      <div className="titleContainer">
        <div>Login</div>
      </div>
      <br />
      <div className="inputContainer">
        <input
          value={email}
          placeholder="Enter your email here"
          onChange={(ev) => setEmail(ev.target.value)}
          className="inputBox"
        />
        <label className="errorLabel">{emailError}</label>
      </div>
      <br />
      <div className="inputContainer">
        <input
          value={password}
          placeholder="Enter your password here"
          onChange={(ev) => setPassword(ev.target.value)}
          className="inputBox"
        />
        <label className="errorLabel">{passwordError}</label>
      </div>
      <br />
      <div className="inputContainer">
        <input className="inputButton" type="button" onClick={onButtonClick} value="Log in" />
      </div>
    </div>
  );
};

export default Login;
