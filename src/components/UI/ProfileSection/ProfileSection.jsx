import React from 'react';
import classes from "./ProfileSection.module.css";

const ProfileSection = ({children, ...props}) => {
    return (
        <section className={classes.ProfileSection} {...props}>
            {children}
        </section>
    );
};

export default ProfileSection;