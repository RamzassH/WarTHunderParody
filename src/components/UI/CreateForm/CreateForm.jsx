import React, {useState} from 'react';
import classes from "./CreateForm.module.css";
import MyInput from "../input/MyInput";
import MyButton from "../button/MyButton";

const CreateForm = ({create}) => {
    const [userData, setUserData] = useState({login: '', username:'', password: '', repeatPassword:''})
    const [errorMessage, setMessage] = useState('')
    let check = false

    const createUser = (e) => {
        e.preventDefault()
        const data = {
            ...userData, id: Date.now()
        }
        try {
            create(data)
            setUserData({login: '', username:'', password: '', repeatPassword:''})
            setMessage('')
        } catch (e) {
            setMessage(e)
        }
    }

    return (
        <div className={classes.CreateFormTable}>
            <div className={classes.CreateFormColumn}>
                <div className={classes.CreateFormInputForm}>
                    <div className={classes.CreateFormTitleText}>Регистрация</div>
                    {errorMessage
                        ?
                        <div className={classes.CreateForm_Access}>
                            <div className={classes.CreateForm_Access_Text}>{errorMessage}</div>
                        </div>
                        :
                        null
                    }

                    <div className={classes.CreateFormRow}>
                        <MyInput
                            id="email"
                            value={userData.login}
                            onChange={e => setUserData({...userData, login: e.target.value})}
                            type="text"
                            placeholder="Адрес электронной почты"
                        />
                    </div>
                    <div className={classes.CreateFormRow}>
                        <MyInput
                            id="username"
                            value={userData.username}
                            onChange={e => setUserData({...userData, username: e.target.value})}
                            type="text"
                            placeholder="Никнейм"
                        />
                    </div>
                    <div className={classes.CreateFormRow}>
                        <MyInput
                            id="password"
                            value={userData.password}
                            onChange={e => setUserData({...userData, password: e.target.value})}
                            type="password"
                            placeholder="Пароль"
                        />
                        <MyInput
                            id="repeatPassword"
                            value={userData.repeatPassword}
                            onChange={e => setUserData({...userData, repeatPassword: e.target.value})}
                            type="password"
                            placeholder="Повторить пароль"
                        />
                    </div>
                    <div className={classes.CreateFormCheckBoxContainer}>
                        <input
                            className={classes.CreateFormCheckBox}
                            type="checkbox"
                            value={check.toString()}
                            onClick={() => {check = !check}}
                        />
                        <div className={classes.CreateFormCheckBoxLabel}>
                            <span>
                                Этот квадратик ничего не делает. На него можно забить продолговатый предмет.
                            </span>
                        </div>
                    </div>
                    <div className={classes.CreateFormRow}>
                        <MyButton onClick={createUser}>
                            Создать аккаунт
                        </MyButton>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default CreateForm;