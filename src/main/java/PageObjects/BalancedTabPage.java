package PageObjects;

import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.PageFactory;

import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.android.AndroidElement;
import io.appium.java_client.pagefactory.AndroidFindBy;
import io.appium.java_client.pagefactory.AppiumFieldDecorator;

public class BalancedTabPage {
	public BalancedTabPage(AndroidDriver<AndroidElement> driver)
	{
		PageFactory.initElements(new AppiumFieldDecorator(driver), this);
	}
	
	@AndroidFindBy(xpath="//*[@Text='Balanced']")
	public WebElement balancedtab;
	
	@AndroidFindBy(xpath="//*[@Text='30']")
	public WebElement cashfund2;
	
	@AndroidFindBy(xpath="//*[@Text='45']")
	public WebElement globalsharefund2;
	
	@AndroidFindBy(xpath="//*[@Text='25']")
	public WebElement propertysharefund2;
	
	public WebElement balancedtabfield()
	{
		return balancedtab;
	}
	
	public WebElement cashfund2field()
	{
		return cashfund2;
	}
	public WebElement globalsharefund2field()
	{
		return globalsharefund2;
	}
	public WebElement propertysharefund2field()
	{
		return propertysharefund2;
	}

}
