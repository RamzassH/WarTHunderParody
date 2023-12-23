import React from 'react';
import classes from "./ProductForm.module.css";

const ProductForm = ({title, image, description, price, buyFunction, ...props}) => {
    return (
        <section className={classes.ProductForm}>
            <div className={classes.ProductForm_Title}>
                {title}
            </div>
            <div className={classes.ProductForm_ContentWrapper}>
                <div className={classes.ProductForm_Gallery}>
                    <div className={classes.ProductForm_SpLide}>
                        <div className={classes.ProductForm_SpLide_Slider}>
                            <div className={classes.ProductForm_SpLide_Slider_Track}>
                                <div className={classes.ProductForm_SpLide_Slide_List}>
                                    <div className={classes.ProductForm_SpLide_Slide}>
                                        <img className={classes.ProductForm_image} src={image}/>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
                <table className={classes.ProductForm_Article_Wrapper}>
                    <tbody>
                        <tr>
                            <td>
                                <div className={classes.ProductForm_Article}>
                                    {description}
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div className={classes.ProductForm_ASide}>
                <div className={classes.ProductForm_ASide_Sticky}>
                    <div className={classes.ProductForm_ShopBuy}>
                        <div className={classes.ProductForm_ShopBuy_Wrapper}>
                            <div className={classes.ProductForm_ShopBuy_Price}>
                                <div className={classes.ProductForm_ShopBuy_Price__}>
                                    {price}
                                </div>
                            </div>
                            <div className={classes.ProductForm_ShopBuy_ButtonWrapper}>
                                <button className={[
                                    classes.ProductForm_ShopBuy_BuyButton_1,
                                    classes.ProductForm_ShopBuy_BuyButton_2,
                                    classes.ProductForm_ShopBuy_BuyButton_3
                                ].join(" ")} onClick={(event) => {event.preventDefault(); buyFunction()}}>
                                    Купить
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    );
};

export default ProductForm;