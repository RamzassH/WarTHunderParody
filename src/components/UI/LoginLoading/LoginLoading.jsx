import React from 'react';
import classes from "./LoginLoading.module.css";


const LoginLoading = () => {
    return (
        <div className={classes.LoginLoading}>
            <div className={classes.LoginLoadingTitle}>
                <div className={classes.LoginLoadingTitleText}>
                    Войти в аккаунт
                </div>
            </div>
            <div className={classes.LoginLoadingTable}>
                <div className={classes.LoginLoadingColumn}>
                    <div className={classes.LoginLoadingInputForm}>
                        <div className={classes.LoginLoadingRow}>
                            <div className={classes.LoginLoadingTitle}>
                                <div className={classes.LoginLoadingTitleText}>
                                    Происходит вход в аккаунт...
                                </div>
                            </div>
                        </div>
                        <div className={classes.LoginLoadingRow}>
                            <div className={classes.LoginLoadingTitle}>
                                <div className={classes.LoginLoadingTitleText}>
                                    Сдерживайте желание выкинуть деньги ещё пару многновений.
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default LoginLoading;