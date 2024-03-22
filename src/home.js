import React from 'react';
import { useNavigate } from 'react-router-dom';

const Home = (props) => {
  const { loggedIn, email } = props;
  const navigate = useNavigate();

  const onButtonClick = (path) => {
    navigate(path);
  };

  return (
    <div className="mainContainer">
      <div className={'titleContainer'}>
        <div>Welcome!</div>
      </div>
      <div className={'buttonContainer'}>
        {loggedIn && <div>Your email address is {email}</div>}
        <input
          className={'inputButton'}
          type="button"
          onClick={() => onButtonClick(loggedIn ? '/logout' : '/login')}
          value={loggedIn ? 'Log out' : 'Continuar como administrador'}
        />
        <input
          className={'inputButton'}
          type="button"
          onClick={() => onButtonClick('/login_chef')}
          value="Continuar como chef"
        />
      </div>
    </div>
  );
};

export default Home;
