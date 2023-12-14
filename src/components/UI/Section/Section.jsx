import React from 'react';
import classes from "./Section.module.css";
const Section = ({children, ...props}) => {
    return (
        <section {...props} className={classes.Section}>
            {children}
        </section>
    );
};

export default Section;