import React, {useState} from 'react';
import MyInput from "../input/MyInput";
import MyButton from "../button/MyButton";
import classes from "./LoginForm.module.css";

const LoginForm = ({login}) => {
    const [userData, setUserData] = useState({login: '', password: ''})


    const loginUser = (e) => {
        e.preventDefault()
        const data = {
            ...userData, id: Date.now()
        }
        login(data)
        setUserData({login: '', password: ''})
    }

    return (
        <div className={classes.LoginModal}>
            <div className={classes.LoginModalTitle}>
                <div className={classes.LoginModalTitleText}>
                    Войти в аккаунт
                </div>
            </div>
            {/*Управляемый компонент*/}

            <div className={classes.LoginModalTable}>
                <div className={classes.LoginModalColumn}>
                    <div className={classes.LoginModalInputForm}>
                        <MyInput
                            value={userData.login}
                            onChange={e => setUserData({...userData, login: e.target.value})}
                            type="text"
                            placeholder="Логин"
                        />
                        {/*Неуправляемый\Неконтролируемый компонент*/}
                        <MyInput
                            value={userData.password}
                            onChange={e => setUserData({...userData, password: e.target.value})}
                            type="text"
                            placeholder="Пароль"
                        />
                        <MyButton
                            className={classes.LoginModalButton}
                            onClick={loginUser}
                        >
                            Войти
                        </MyButton>
                    </div>
                </div>
            </div>

        </div>
    );
};

export default LoginForm;