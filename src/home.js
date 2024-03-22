import React from 'react'
import { useNavigate } from 'react-router-dom'

const Home = (props) => {
  const { loggedIn, email } = props
  const navigate = useNavigate()

  const onButtonClick = () => {
    if (loggedIn) {
      // Si el usuario ya está autenticado, lo redirigimos a la página de logout
      navigate('/logout') // Cambia '/logout' con la ruta a la que quieres redirigir al usuario
    } else {
      // Si el usuario no está autenticado, lo redirigimos a la página de login
      navigate('/login') // Cambia '/login' con la ruta a la que quieres redirigir al usuario
    }
  }

  return (
    <div className="mainContainer">
      <div className={'titleContainer'}>
        <div>Welcome!</div>
      </div>
      <div>This is the home page.</div>
      <div className={'buttonContainer'}>
        <input
          className={'inputButton'}
          type="button"
          onClick={onButtonClick}
          value={loggedIn ? 'Log out' : 'Log in'}
        />
        {loggedIn ? <div>Your email address is {email}</div> : <div />}
      </div>
    </div>
  )
}

export default Home
