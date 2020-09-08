package TechnicalTest.Project;

import java.io.File;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.concurrent.TimeUnit;

import org.openqa.selenium.remote.DesiredCapabilities;

import io.appium.java_client.android.AndroidDriver;
import io.appium.java_client.android.AndroidElement;
import io.appium.java_client.remote.MobileCapabilityType;

public class base {
	
	public static AndroidDriver<AndroidElement>  driver;
	
	public static  AndroidDriver<AndroidElement> capabilities() throws MalformedURLException
	{
	

		// TODO Auto-generated method stub
	 File appDir = new File("src");
     File app = new File(appDir, "AppName.apk");
     DesiredCapabilities capabilities = new DesiredCapabilities();
     
     capabilities.setCapability(MobileCapabilityType.DEVICE_NAME, "Android");
     capabilities.setCapability(MobileCapabilityType.AUTOMATION_NAME,"uiautomator2");
     capabilities.setCapability(MobileCapabilityType.NEW_COMMAND_TIMEOUT,14);
     capabilities.setCapability(MobileCapabilityType.APP, app.getAbsolutePath());
    driver = new AndroidDriver<>(new URL("http://127.0.0.1:4723/wd/hub"), capabilities);
    driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
	    
	    return driver;
	}
	
	


}
