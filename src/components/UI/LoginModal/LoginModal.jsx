import React from 'react';
import cl from "./LoginModal.module.css";

const LoginModal = ({children, visible, setVisible}) => {

    const rootClasses = [cl.LoginModal]

    if (visible) {
        rootClasses.push(cl.active);
    }

    return (
        <div className={rootClasses.join(' ')} onClick={() => setVisible(false)}>
            <div className={cl.LoginModalContent} onClick={(e) => e.stopPropagation()}>
                {children}
            </div>
        </div>
    );
};

export default LoginModal;