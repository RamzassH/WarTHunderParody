import React from 'react';
import classes from "./ProfileInfo.module.css";

const ProfileInfo = ({username, id, email, meta}) => {
    return (
        <div className={classes.ProfileInfo}>
            <div className={classes.ProfileInfo_InfoContainer}>
                <div className={classes.ProfileInfo_InfoContainer_Wrapper}>
                    <div className={classes.ProfileInfo_Username}>
                        {username}
                    </div>
                    <div className={classes.ProfileInfo_Id}>
                        <div className={classes.ProfileInfo_Id__}>
                            <div className={classes.ProfileInfo_Id__Label}>ID:</div>
                            <span>{id}</span>
                        </div>
                    </div>
                    <div className={classes.ProfileInfo_Email}>
                        {email}
                    </div>
                    <div className={classes.ProfileInfo_Meta}>
                        Зарегистрирован {meta}
                    </div>
                </div>
            </div>
        </div>
    );
};

export default ProfileInfo;