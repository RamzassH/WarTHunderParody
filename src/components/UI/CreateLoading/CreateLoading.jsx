import React from 'react';
import classes from "./CreateLoading.module.css";

const CreateLoading = () => {
    return (
        <div className={classes.CreateLoading}>
            <div className={classes.CreateLoadingTitle}>
                <div className={classes.CreateLoadingTitleText}>
                    Регистрация
                </div>
            </div>
            <div className={classes.CreateLoadingTable}>
                <div className={classes.CreateLoadingColumn}>
                    <div className={classes.CreateLoadingInputForm}>
                        <div className={classes.CreateLoadingRow}>
                            <div className={classes.CreateLoadingTitle}>
                                <div className={classes.CreateLoadingTitleText}>
                                    Происходит создание нового аккаунта...
                                </div>
                            </div>
                        </div>
                        <div className={classes.CreateLoadingRow}>
                            <div className={classes.CreateLoadingTitle}>
                                <div className={classes.CreateLoadingTitleText}>
                                    Отныне ваша душа и номер коедитки принадлежат нам.
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default CreateLoading;