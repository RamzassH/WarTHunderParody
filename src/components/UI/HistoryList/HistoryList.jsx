import React from 'react';
import classes from "./HistoryList.module.css";

const HistoryList = ({children}) => {
    return (
        <section>
            <div className={classes.Content_Wrapper}>
                {children}
            </div>
        </section>
    );
};

export default HistoryList;