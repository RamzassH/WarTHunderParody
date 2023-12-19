import React from 'react';
import cl from "./CreateModal.module.css";

const CreateModal = ({children, visible, setVisible}) => {

    const rootClasses = [cl.CreateModal]

    if (visible) {
        rootClasses.push(cl.active);
    }

    return (
        <div className={rootClasses.join(' ')} onClick={() => setVisible(false)}>
            <div className={cl.CreateModalContent} onClick={(e) => e.stopPropagation()}>
                {children}
            </div>
        </div>
    );
};

export default CreateModal;