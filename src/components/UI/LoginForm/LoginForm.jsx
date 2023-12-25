import React, {useState} from 'react';
import MyInput from "../input/MyInput";
import MyButton from "../button/MyButton";
import classes from "./LoginForm.module.css";

const LoginForm = ({login, create}) => {
    const [userData, setUserData] = useState({login: '', password: ''})
    const [errorMessage, setMessage] = useState('')

    const loginUser = (e) => {
        e.preventDefault()
        const data = {
            ...userData, id: Date.now()
        }
        console.log(userData)
        try {
            login(data)
            setUserData({login: '', password: ''})
            setMessage('')
        } catch (e) {
            setMessage(e)
        }
    }

    const createUser = (e) => {
        e.preventDefault()
        create()
    }

    return (
        <div className={classes.LoginModal}>
            <div className={classes.LoginModalTitle}>
                <div className={classes.LoginModalTitleText}>
                    Войти в аккаунт
                </div>
            </div>
            <div className={classes.LoginModalTable}>
                <div className={classes.LoginModalColumn}>
                    {errorMessage ?
                        <div className={classes.LoginForm_Access}>
                            <div className={classes.LoginForm_Access_Text}>{errorMessage}</div>
                        </div>
                        :
                        null
                    }
                    <div className={classes.LoginModalInputForm}>
                        <div className={classes.LoginFormRow}>
                            <MyInput
                                id="email"
                                value={userData.login}
                                onChange={e => setUserData({...userData, login: e.target.value})}
                                type="text"
                                placeholder="Логин"
                            />
                        </div>
                        <div className={classes.LoginFormRow}>
                            <MyInput
                                id="password"
                                value={userData.password}
                                onChange={e => setUserData({...userData, password: e.target.value})}
                                type="password"
                                placeholder="Пароль"
                            />
                        </div>
                        <div className={classes.LoginFormRow}>
                            <MyButton
                                onClick={loginUser}
                            >
                                Войти
                            </MyButton>
                        </div>

                    </div>
                </div>
                <div className={classes.LoginModalColumn}>
                    <div className={classes.LoginFormCenter}>
                        <p>
                            Создать учётную запись Gay Web Site -
                            <br/>
                            просто, быстро и бесплатно(ПОКА).
                            <br/>
                            По ссылке в описании
                        </p>
                        <input
                            className={classes.LoginFormCreateButton}
                            type="submit"
                            value="Заложить квартиру"
                            onClick={createUser}
                        />
                    </div>
                </div>
            </div>
        </div>
    );
};

export default LoginForm;