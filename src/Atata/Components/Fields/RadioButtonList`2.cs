﻿using System.Linq;
using OpenQA.Selenium;

namespace Atata
{
    /// <summary>
    /// Represents the radio button list control (a set of &lt;input type="radio"&gt;).
    /// </summary>
    /// <typeparam name="T">The type of the control's data. Supports string, enum types, numeric types and others.</typeparam>
    /// <typeparam name="TOwner">The type of the owner page object.</typeparam>
    [ControlDefinition("input[@type='radio']", IgnoreNameEndings = "RadioButtons,RadioButtonList,Radios,RadioGroup,Buttons,ButtonList,Options,OptionGroup")]
    public class RadioButtonList<T, TOwner> : OptionList<T, TOwner>
        where TOwner : PageObject<TOwner>
    {
        protected override T GetValue()
        {
            IWebElement selectedItem = GetItemElements().FirstOrDefault(x => x.Selected);
            if (selectedItem != null)
                return GetElementValue(selectedItem);
            else
                return default(T);
        }

        protected override void SetValue(T value)
        {
            value.CheckNotNull("value", "Cannot set \"null\" to RadioButtonList control.");

            IWebElement element = GetItemElement(value);
            if (!element.Selected)
                element.Click();
        }
    }
}
